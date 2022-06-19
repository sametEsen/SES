import { ResultModelTypeEnum } from "./enumerations/result-model.type";

export class ResultModel {
    constructor(
        public Type: ResultModelTypeEnum,
        public Message: string) { }
}