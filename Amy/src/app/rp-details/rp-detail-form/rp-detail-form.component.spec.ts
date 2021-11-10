import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RpDetailFormComponent } from './rp-detail-form.component';

describe('RpDetailFormComponent', () => {
  let component: RpDetailFormComponent;
  let fixture: ComponentFixture<RpDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RpDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RpDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
