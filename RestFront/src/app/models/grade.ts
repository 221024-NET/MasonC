export class Grade {
    id: number
    grade: number
    restId: number
    constructor (
        id: number,
        grade: number,
        restID: number
    ) {
        this.id = id;
        this.grade = grade;
        this.restId = restID;
    }
}