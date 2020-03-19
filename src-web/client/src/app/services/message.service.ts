import { Injectable } from '@angular/core';

export enum MessageType {
    Info,
    Warning,
    Error
}

@Injectable()
export class MessageService {
    private _toastMessage: string;
    private _messageType: MessageType;

    get Message(): string {
        return this._toastMessage;
    }

    get Type(): MessageType {
        return this._messageType;
    }

    Toast(message: string, type: MessageType) {
        this._toastMessage = message;
        this._messageType = type;
    }

    Hide(): void {
        this._toastMessage = undefined;
        this._messageType = undefined;
    }
}