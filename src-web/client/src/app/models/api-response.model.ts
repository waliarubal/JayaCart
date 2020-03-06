import { Deserializer } from '@app/deserializer';

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
        return Deserializer.Deserialize<T>(apiResponse.Response);
    }

    static GetResponseArray<T>(apiResponse: ApiResponse, key?: string): T[] {
        return Deserializer.DeserializeArray(apiResponse.Response, key);
    }
}