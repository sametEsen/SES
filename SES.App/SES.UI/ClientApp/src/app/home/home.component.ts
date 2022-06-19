import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { KataRequestModel, ResultModel } from '../models';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  private subscriptions: Array<Subscription> = [];
  public result!: ResultModel;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    let requestModel = <KataRequestModel>{
      NumberList: [0]
    }

    this.subscriptions.push(this.dataService.getResult(requestModel).subscribe((data: ResultModel) => {
      this.result = data;
    }));
  }

}
