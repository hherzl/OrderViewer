export interface IListResponse<T> {
    model: T[];
    message: string;
    didError: boolean;
    errorMessage: string;
}

export class ListResponse<T> implements IListResponse<T> {
    public model: T[];
    public message: string;
    public didError: boolean;
    public errorMessage: string;
}
