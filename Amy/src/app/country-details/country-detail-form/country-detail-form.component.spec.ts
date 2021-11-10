import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryDetailFormComponent } from './country-detail-form.component';

describe('CountryDetailFormComponent', () => {
  let component: CountryDetailFormComponent;
  let fixture: ComponentFixture<CountryDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountryDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
