import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayRestsComponent } from './components/display-rests/display-rests.component';
import { EditRestComponent } from './components/edit-rest/edit-rest.component';
import { RestDetailsComponent } from './components/rest-details/rest-details.component';


const routes: Routes = [
  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "home", component: DisplayRestsComponent },
  { path: "edit", component: EditRestComponent },
  { path: "details", component: RestDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
