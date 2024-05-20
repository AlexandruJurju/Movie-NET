import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {ActorDto, ActorService} from "../../services/swagger";

@Component({
  selector: 'app-actor-details',
  standalone: true,
  imports: [],
  templateUrl: './actor-details.component.html',
  styleUrl: './actor-details.component.css'
})
export class ActorDetailsComponent implements OnInit {

  actor: ActorDto = {} as ActorDto

  constructor(private actorService: ActorService,
              private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit() {
    const actorId = +this.route.snapshot.paramMap.get('id')!;

    if (actorId === null || isNaN(actorId)) {
      this.router.navigate(['/error']);
      return;
    }

    this.actorService.findActorById(actorId).subscribe({
      next: actor => {
        this.actor = actor;
      }
    })

  }

}
