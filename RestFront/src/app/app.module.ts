import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RestaurantComponent } from './components/restaurant/restaurant.component';
import { DisplayRestsComponent } from './components/display-rests/display-rests.component';
import { RestDetailsComponent } from './components/rest-details/rest-details.component';
import { EditRestComponent } from './components/edit-rest/edit-rest.component';
import { DisplayCuisineComponent } from './components/display-cuisine/display-cuisine.component';
import { DisplayGradeComponent } from './components/display-grade/display-grade.component';
import { DisplayMenuComponent } from './components/display-menu/display-menu.component';
import { DisplayScoreComponent } from './components/display-score/display-score.component';
import { CuisineComponent } from './components/cuisine/cuisine.component';
import { GradeComponent } from './components/grade/grade.component';
import { ScoreComponent } from './components/score/score.component';
import { MenuComponent } from './components/menu/menu.component';

@NgModule({
  declarations: [
    AppComponent,
    RestaurantComponent,
    DisplayRestsComponent,
    RestDetailsComponent,
    EditRestComponent,
    DisplayCuisineComponent,
    DisplayGradeComponent,
    DisplayMenuComponent,
    DisplayScoreComponent,
    CuisineComponent,
    GradeComponent,
    ScoreComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
