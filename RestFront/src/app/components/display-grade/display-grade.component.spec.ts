import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayGradeComponent } from './display-grade.component';

describe('DisplayGradeComponent', () => {
  let component: DisplayGradeComponent;
  let fixture: ComponentFixture<DisplayGradeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayGradeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayGradeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
