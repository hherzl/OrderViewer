import { OrderDetail } from "./order.detail";

export class Order {

    public salesOrderID: number;

    public orderDate: Date;

    public dueDate: Date;

    public shipDate: Date;

    public salesOrderNumber: string;

    public orderDetails: OrderDetail[];
}
