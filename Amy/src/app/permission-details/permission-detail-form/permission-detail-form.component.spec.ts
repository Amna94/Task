import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PermissionDetailFormComponent } from './permission-detail-form.component';

describe('PermissionDetailFormComponent', () => {
  let component: PermissionDetailFormComponent;
  let fixture: ComponentFixture<PermissionDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PermissionDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PermissionDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
