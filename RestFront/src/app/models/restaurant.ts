export class Restaurant {
    id: number
    name: string
    street_addr: string
    city: string
    state: string

    constructor (
        id: number,
        name: string,
        street_addr: string,
        city: string,
        state: string,

    ) {
        this.id = id;
        this.name = name;
        this.street_addr = street_addr;
        this.city = city;
        this.state = state;
    }
}