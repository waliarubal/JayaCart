import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '@models/api-response.model';
import { ApiUrl } from '@shared/constants';

export abstract class BaseService {
    private readonly COLLECTION_NAME: string;

    constructor(private readonly _http: HttpClient, collectionName: string) {
        this.COLLECTION_NAME = collectionName;
    }

    protected GetAll<T>(): Promise<T[]> {
        return new Promise<T[]>((resolve, reject) => {
            this._http.get<ApiResponse>(`${ApiUrl}${this.COLLECTION_NAME}`).subscribe(
                success => {
                    if (success.IsHavingError)
                        reject(success.Error);
                    else {
                        let accounts = ApiResponse.GetResponseArray<T>(success, this.COLLECTION_NAME);
                        resolve(accounts);
                    }
                },
                error => reject(error));
        });
    }

}