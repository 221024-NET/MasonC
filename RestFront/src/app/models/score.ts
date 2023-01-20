export class Score {
    id: number
    score: number
    restId: number
    date_submit: Date

    constructor (
        id: number,
        score: number,
        date_submit: Date,
        restID: number
    ) {
        this.id = id;
        this.score = score;
        this.date_submit = date_submit;
        this.restId = restID;
    }
}