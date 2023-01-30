export class Score {
    id: number
    score: number
    restId: number
    date_submit: Date

    constructor (
        id: number,
        score: number,
        date_submit: Date,
        restId: number
    ) {
        this.id = id;
        this.score = score;
        this.date_submit = date_submit;
        this.restId = restId;
    }
}