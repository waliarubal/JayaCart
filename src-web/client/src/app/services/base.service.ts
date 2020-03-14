import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiResponse } from '@models/api-response.model';
import { API_URL } from '@shared/constants';

const HTTP_OPTIONS = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

export abstract class BaseService {
    private readonly COLLECTION_NAME: string;

    constructor(private readonly _http: HttpClient, collectionName: string) {
        this.COLLECTION_NAME = collectionName;
    }

    protected GetAll<T>(): Promise<T[]> {
        return new Promise<T[]>((resolve, reject) => {
            this._http.get<ApiResponse>(`${API_URL}${this.COLLECTION_NAME}`).subscribe(
                success => {
                    if (success.IsHavingError)
                        reject(success.Error);
                    else {
                        let records = ApiResponse.GetResponseArray<T>(success);
                        resolve(records);
                    }
                },
                error => reject(error));
        });
    }

    protected Post<T>(record: any, url?: string): Promise<T> {
        let endPoint = `${API_URL}${this.COLLECTION_NAME}`;
        if (url)
            endPoint += `/${url}`;
            
        return new Promise<T>((resolve, reject) => {
            this._http.post<ApiResponse>(`${API_URL}${this.COLLECTION_NAME}`, record, HTTP_OPTIONS).subscribe(
                success => {
                    if (success.IsHavingError)
                        reject(success.Error);
                    else {
                        let record = ApiResponse.GetResponse<T>(success);
                        resolve(record);
                    }
                },
                error => reject(error)
            )
        });
    }
}