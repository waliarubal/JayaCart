import * as firebaseHelper from 'firebase-functions-helper';
import * as HttpStatus from 'http-status-codes';
import { BaseService, HttpMethod } from "./base.service";
import { Category } from "../models";

const CATEGORIES = 'Categories';

export class CategoryService extends BaseService {

    private async Create(request, response) {
        try {
            let category: Category = {
                Code: request.body['Code'],
                Name: request.body['Name'],
                Description: request.body['Description'] ?? ''
            };

            let isCreated = await firebaseHelper.firestore.createDocumentWithID(this.Database, CATEGORIES, category.Code, category);
            if (isCreated)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<Category>(category));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<Category>(`Failed to create category: ${category}`));
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<Category>(`Failed to create category. ${ex}`));
        }
    }

    private async Update(request, response) {
        try {
            let updatedRecord = await firebaseHelper.firestore.updateDocument(this.Database, CATEGORIES, request.params.Code, request.body);
            if (updatedRecord)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<Category>(updatedRecord));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<Category>(`Failed to update category with code ${request.params.Code}.`));
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<Category>(`Failed to update category with code ${request.params.Code}. ${ex}`));
        }
    }

    private async Get(code: string) {
        let record = await firebaseHelper.firestore.getDocument(this.Database, CATEGORIES, code);
        if (record)
            return this.Deserialize<Category>(record);
        else
            return undefined;
    }

    private async GetByCode(request, response) {
        try {
            let record = await this.Get(request.params.Code);
            if (record)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<Category>(record));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<Category>(`Category with code ${request.params.Code} does not exist.`))

        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<Category>(`Category with code ${request.params.Code}: ${ex}`))
        }
    }

    private async GetMany(request, response) {
        try {
            let records = await firebaseHelper.firestore.backup(this.Database, CATEGORIES)
            if (records)
                response
                    .status(HttpStatus.OK)
                    .json(this.ResultArray<Category[]>(records, CATEGORIES));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<Category[]>(`Failed to get categories.`))
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<Category>(`Failed to get categories: ${ex}`))
        }
    }

    private async Delete(request, response) {
        const deletedRecord = await firebaseHelper.firestore.deleteDocument(this.Database, CATEGORIES, request.params.Code);
        if (deletedRecord)
            response
                .status(HttpStatus.OK)
                .json(this.Result<object>(deletedRecord));
        else
            response
                .status(HttpStatus.OK)
                .json(this.Error<Category>(`Failed to delete category with code ${request.params.Code}.`))
    }

    RegisterMethods(): void {
        this.RegisterMethod(HttpMethod.Post, `/${CATEGORIES}`, async (request, response) => await this.Create(request, response));
        this.RegisterMethod(HttpMethod.Patch, `/${CATEGORIES}/:Code`, async (request, response) => await this.Update(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${CATEGORIES}/:Code`, async (request, response) => await this.GetByCode(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${CATEGORIES}`, async (request, response) => await this.GetMany(request, response));
        this.RegisterMethod(HttpMethod.Delete, `/${CATEGORIES}/:Code`, async (request, response) => await this.Delete(request, response));
    }

}