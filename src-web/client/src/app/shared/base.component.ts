import { NgForm } from '@angular/forms';
import { ViewChild } from '@angular/core';
import { KeyValue } from '@angular/common';
import { MessageService, MessageType } from '@services/message.service';
import { Router } from '@angular/router';

export abstract class BaseComponent {
    private readonly _validationMessages: Map<string, Map<string, string>>;
    private _validationError: string;
    private _isBusy: boolean;

    @ViewChild('form', { static: false })
    private _form: NgForm;

    protected constructor(
        private readonly _messageService: MessageService,
        private readonly _router: Router) {
        this._validationMessages = new Map();
    }

    get IsBusy(): boolean {
        return this._isBusy;
    }

    set IsBusy(value: boolean) {
        if (value === this._isBusy)
            return;

        this._isBusy = value;
        if (value)
            this.Disable();
        else
            this.Enable();
    }

    get ValidationError(): string {
        return this._validationError;
    }

    protected get Form(): NgForm {
        return this._form;
    }

    protected Navigate(url: string, ...data: any[]): Promise<boolean> {
        let params: any[] = [];
        params.push(url);
        for(let d of data)
            params.push(d);

        return this._router.navigate(params);
    }

    protected Enable(form?: NgForm): void {
        if (!form)
            form = this.Form;
        if (!form)
            return;

        if (form.form.disabled)
            form.form.enable();
    }

    protected Disable(form?: NgForm): void {
        if (!form)
            form = this.Form;
        if (!form)
            return;

        if (form.form.enabled)
            form.form.disable();
    }

    protected Clear(form?: NgForm, value?: any, focusOnControl?: string): void {
        if (!form)
            form = this.Form;
        if (!form)
            return;

        if (value)
            form.form.reset(value);
        else
            form.form.reset();

        if (focusOnControl)
            this.Focus(focusOnControl);
    }

    protected SetValidationMessage(controlName: string, ...messages: KeyValue<string, string>[]): void {
        if (!controlName || messages.length === 0)
            return;

        const messageMap = new Map<string, string>();
        for (let message of messages)
            messageMap.set(message.key, message.value);

        this._validationMessages.set(controlName, messageMap);
    }

    protected Focus(controlName: string): void {
        let controls = document.getElementsByName(controlName);
        if (controls && controls.length > 0)
            controls[0].focus();
    }

    protected Toast(message: string, type: MessageType): void {
        this._messageService.Toast(message, type);
    }

    protected Validate(form?: NgForm, ...skipControls: string[]): boolean {
        if (!this._validationMessages || this._validationMessages.size === 0)
            return true;

        if (!form)
            form = this.Form;
        if (!form)
            return true;

        form.form.markAllAsTouched();

        let controlNames = Object.keys(form.form.controls);
        for (let controlName of controlNames) {
            if (skipControls.indexOf(controlName) > -1 || !this._validationMessages.has(controlName))
                continue;

            let control = form.form.get(controlName);
            if (!control)
                continue;

            if (!control.valid && (control.dirty || control.touched)) {
                let errorMessages = this._validationMessages.get(controlName);

                for (let errorKey in control.errors) {
                    if (errorMessages.has(errorKey)) {
                        this._validationError = errorMessages.get(errorKey);
                        this.Toast(this._validationError, MessageType.Error);
                        this.Focus(controlName);
                        return false;
                    }
                }
            }
        }

        return true;
    }
}