export interface IListResponse<TModel> {
    message: string;
    didError: boolean;
    errorMessage: string;
    model: TModel[];
    pageSize: number;
    pageNumber: number;
    itemsCount: number;
    pageCount: number;
}

export class ListResponse<TModel> implements IListResponse<TModel> {
    public message: string;
    public didError: boolean;
    public errorMessage: string;
    public model: TModel[];
    public pageSize: number;
    public pageNumber: number;
    public itemsCount: number;
    public pageCount: number;

    public constructor() {
        this.pageSize = 10;
        this.pageNumber = 1;
    }
}
