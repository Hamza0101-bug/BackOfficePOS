
import {v4 as uuidv4} from 'uuid';
export interface IBasket {
    id: string;
    items: IBasketItem[];
   
}

export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: string;
    category: string;
    branch: string;
}

export class Basket implements IBasket {
    id = uuidv4();
    items: IBasketItem[] = [];
}
 export interface IBasketTotals
 {
     shipping: number;
     subtotal: Number;
     total:number;
 }

// clientSecret?: string;
// paymentIntentId?: string;
// deliveryMethodId?: number;
// shippingPrice?: number;