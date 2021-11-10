import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersDetailFormComponent } from './users-detail-form.component';

describe('UsersDetailFormComponent', () => {
  let component: UsersDetailFormComponent;
  let fixture: ComponentFixture<UsersDetailFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersDetailFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
