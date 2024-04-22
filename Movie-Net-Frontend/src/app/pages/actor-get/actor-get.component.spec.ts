import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActorGetComponent } from './actor-get.component';

describe('ActorGetComponent', () => {
  let component: ActorGetComponent;
  let fixture: ComponentFixture<ActorGetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActorGetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ActorGetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
