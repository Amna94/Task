import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleDetailFormComponent } from './role-detail-form.component';

describe('RoleDetailFormComponent', () => {
  let component: RoleDetailFormComponent;
  let fixture: ComponentFixture<RoleDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoleDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoleDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
