export interface IListResponse<TModel> {
    model: TModel[];
    message: string;
    didError: boolean;
    errorMessage: string;
    pageSize: number;
    pageNumber: number;
}

export class ListResponse<TModel> implements IListResponse<TModel> {
    public model: TModel[];
    public message: string;
    public didError: boolean;
    public errorMessage: string;
    public pageSize: number;
    public pageNumber: number;
}
