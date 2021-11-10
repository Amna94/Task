import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityDetailFormComponent } from './city-detail-form.component';

describe('CityDetailFormComponent', () => {
  let component: CityDetailFormComponent;
  let fixture: ComponentFixture<CityDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CityDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CityDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
