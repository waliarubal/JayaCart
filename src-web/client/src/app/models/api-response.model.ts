export class ApiResponse {
    Error: string;
    Response: any;
    IsHavingError: boolean;

    constructor(response: any, error: string = undefined) {
        this.Response = response;
        this.Error = error;
        this.IsHavingError = error !== undefined;
    }

    static GetResponse<T>(apiResponse: ApiResponse): T {
        return apiResponse.Response;
    }

    static GetResponseArray<T>(apiResponse: ApiResponse): T[] {
        return apiResponse.Response;
    }
}