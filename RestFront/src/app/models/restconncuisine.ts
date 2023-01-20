export class RestConnCuisine {
    id: number
    name: string
    restId: number
    cuisineId: number
    constructor (
        id: number,
        name: string,
        cuisineId: number,
        restId: number
    ) {
        this.id = id;
        this.name = name;
        this.cuisineId = cuisineId;
        this.restId = restId;
    }
}