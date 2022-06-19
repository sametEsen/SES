import { Injectable } from "@angular/core";
import { Observable} from "rxjs";
import { KataRequestModel, ResultModel } from "../models/index";
import { DataRepository } from "./data-repository.service";

@Injectable({ providedIn: 'root' })

export class DataService {
    private getKataResultUrl = 'Kata/GetResult'

    constructor(private dataRepository: DataRepository) {

    }

    public getResult(requestModel: KataRequestModel): Observable<ResultModel> {
        return this.dataRepository.postItem<ResultModel>(this.getKataResultUrl, requestModel);
    }
}