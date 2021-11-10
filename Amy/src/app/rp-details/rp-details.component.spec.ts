import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RpDetailsComponent } from './rp-details.component';

describe('RpDetailsComponent', () => {
  let component: RpDetailsComponent;
  let fixture: ComponentFixture<RpDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RpDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RpDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
