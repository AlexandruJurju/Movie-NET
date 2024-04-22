import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActorSaveComponent } from './actor-save.component';

describe('ActorSaveComponent', () => {
  let component: ActorSaveComponent;
  let fixture: ComponentFixture<ActorSaveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActorSaveComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ActorSaveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
