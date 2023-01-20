export class Menu {
    id: number
    name: string
    price: number
    restId: number
    constructor (
        id: number,
        name: string,
        price: number,
        restId: number
    ) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.restId = restId;
    }
}