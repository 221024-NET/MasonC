import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Menu } from 'src/app/models/Menu';
import { Restaurant } from 'src/app/models/Restaurant';
import { MenuService } from 'src/app/services/menu.service';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-display-menu',
  templateUrl: './display-menu.component.html',
  styleUrls: ['./display-menu.component.css']
})
export class DisplayMenuComponent {
  private router: Router;
  public menu: Menu[] = [];
  private menuService: MenuService;
  
  private restService: RestaurantService;
  private rest: Restaurant[] = [];

  constructor(router: Router, 
     menuService: MenuService,
     restService: RestaurantService){

      this.restService = restService;
      this.menuService = menuService;
      this.router = router;

      this.rest.push(this.restService.getStoredRest());
      this.restService.setRest(this.rest[0]);

      this.menuService.getMenu(this.rest[0].id).subscribe(
        data => {this.menu = data;
        //console.log("In display menu");
        //console.log(this.menu);
        }
      );

      // console.log("In display menu");
      //console.log(this.menu);
  }

}
