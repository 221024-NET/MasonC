import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cuisine } from 'src/app/models/Cuisine';
import { Grade } from 'src/app/models/Grade';
import { Restaurant } from 'src/app/models/Restaurant';
import { CuisineService } from 'src/app/services/cuisine.service';
import { GradeService } from 'src/app/services/grade.service';
import { RestConnCuisineService } from 'src/app/services/rest-conn-cuisine.service';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-display-grade',
  templateUrl: './display-grade.component.html',
  styleUrls: ['./display-grade.component.css']
})
export class DisplayGradeComponent {
  
  private router: Router;
  public grade: Grade[] = [];
  private gradeService: GradeService;
  
  private restService: RestaurantService;
  private rest: Restaurant[] = [];

  constructor(router: Router, 
     gradeService: GradeService,
     restService: RestaurantService){

      this.restService = restService;
      this.gradeService = gradeService;
      this.router = router;

      this.rest.push(this.restService.getStoredRest());
      this.restService.setRest(this.rest[0]);

      this.gradeService.getGrade(this.rest[0].id).subscribe(
        data => this.grade = data
      )
  }

}
