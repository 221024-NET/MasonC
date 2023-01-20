import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayMenuComponent } from './display-menu.component';

describe('DisplayMenuComponent', () => {
  let component: DisplayMenuComponent;
  let fixture: ComponentFixture<DisplayMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayMenuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
