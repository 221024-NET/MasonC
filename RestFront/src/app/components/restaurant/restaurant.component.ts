import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { Restaurant } from '../../models';

@Component({
  selector: 'app-restaurant-component',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent {
  rests: Restaurant[] = [];


  constructor(private router: Router,
    private restService: RestaurantService){}


  ngOnInit(): void {}

}
