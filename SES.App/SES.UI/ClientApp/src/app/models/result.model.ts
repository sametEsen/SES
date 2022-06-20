import { ResultModelTypeEnum } from "./enumerations/result-model.type";

export class ResultModel {
    constructor(
        public type: ResultModelTypeEnum,
        public message: string) { }
}