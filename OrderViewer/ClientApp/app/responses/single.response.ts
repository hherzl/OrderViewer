export interface ISingleResponse<TModel> {
    model: TModel;
    message: string;
    didError: boolean;
    errorMessage: string;
}

export class SingleResponse<TModel> implements ISingleResponse<TModel> {
    public model: TModel;
    public message: string;
    public didError: boolean;
    public errorMessage: string;
}
