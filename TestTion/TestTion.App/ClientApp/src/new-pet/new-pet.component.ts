import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Pet} from "../models/pet";
import {PetService} from "../services/pet.service";
import {finalize} from "rxjs/operators";

@Component({
  selector: 'new-pet',
  templateUrl: './new-pet.component.html',
  styleUrls: ['./new-pet.component.scss']
})
export class NewPetComponent implements OnInit {

  public types: string[] = ['Parrot', 'Cat', 'Dog'];

  @Input() pet: Pet;
  @Output() onSaved: EventEmitter<any> = new EventEmitter<any>();

  constructor(private petService: PetService) { }

  ngOnInit() {
  }

  public save(): void{

    if (this.pet.id)
    {
      this.petService.save(this.pet).subscribe(() => this.onSaved.emit());
    }
    else {
      this.petService.create(this.pet).subscribe(() => this.onSaved.emit());
    }
  }
}
