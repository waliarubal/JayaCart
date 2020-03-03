export class ApiResponse<T> {
    Error: string;
    Response: T;
    IsHavingError: boolean;

    constructor(response: T, error: string = undefined) {
        this.Response = response;
        this.Error = error;
        this.IsHavingError = error !== undefined;
    }
}