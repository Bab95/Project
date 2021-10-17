import { makeObservable, observable } from "mobx";

export default class ActivityStore{
    title = 'using MobX';
    constructor() {
        makeObservable(this, {
            title:observable
        })
    }
}