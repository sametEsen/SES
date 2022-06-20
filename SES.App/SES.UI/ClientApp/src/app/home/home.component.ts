import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { NumberExtension } from '../common/extensions/numbers.extensions';
import { KataRequestModel, ResultModel } from '../models';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  private subscriptions: Array<Subscription> = [];
  public result!: ResultModel;
  public inputValue: string = '';

  constructor(private dataService: DataService) { }

  ngOnInit(): void { }

  public getResult(): void{
    if(this.inputValue == null || this.inputValue.length === 0){
      alert("Please fill some numbers!");
      return;
    }

    var numberList = this.inputValue.replace(/,\s*$/, "").split(',').map(Number);
    var numberListControl = NumberExtension.checkIntegerList(numberList);
    if(!numberListControl){
      alert("Please type only integer!");
      return;
    }

    let requestModel = <KataRequestModel>{
      NumberList: numberList
    }
    this.subscriptions.push(this.dataService.getResult(requestModel).subscribe((data: ResultModel) => {
      this.result = data;
    }));
  }

  ngOnDestroy(): void{
    this.subscriptions.forEach(s => s.unsubscribe());
  }

}
