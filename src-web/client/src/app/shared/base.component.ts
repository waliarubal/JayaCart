import { NgForm } from '@angular/forms';
import { ViewChild } from '@angular/core';

export abstract class BaseComponent {
    @ViewChild('form', { static: true }) private _form: NgForm;

    IsBusy: boolean;

    protected get Form(): NgForm {
        return this._form;
    }

    protected Enable(form?: NgForm): void {
        if (!form)
            form = this.Form;

        if (form.form.disabled)
            form.form.enable();
    }

    protected Disable(form?: NgForm): void {
        if (!form)
            form = this.Form;

        if (form.form.enabled)
            form.form.disable();
    }

    protected Clear(form?: NgForm): void {
        if (!form)
            form = this.Form;

        form.form.reset();
    }
}