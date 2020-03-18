import { Injectable } from '@angular/core';

@Injectable()
export class MessageService {
    private _message: string;
    private _class: string;

    get Message(): string {
        return this._message;
    }

    get CssClass(): string {
        return this._class;
    }

    Toast(message: string, cssClass: string) {
        this._message = message;
        this._class = cssClass;
    }

    HideToast(): void {
        this._message = undefined;
        this._class = undefined;
    }
}