export interface ISingleResponse<TModel> {
    message: string;
    didError: boolean;
    errorMessage: string;
    model: TModel;
}

export class SingleResponse<TModel> implements ISingleResponse<TModel> {
    public message: string;
    public didError: boolean;
    public errorMessage: string;
    public model: TModel;
}
