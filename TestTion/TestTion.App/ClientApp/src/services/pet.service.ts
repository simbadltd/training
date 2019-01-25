import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ApiService} from "./api.service";
import {Pet} from "../models/pet";

@Injectable()
export class PetService extends ApiService
{
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    super(http, baseUrl);
  }

  public all(): Observable<Pet[]>
  {
    return this.getAsJson(`api/pet`) as Observable<Pet[]>;
  }

  public save(item: Pet): Observable<void>
  {
    return this.putAsJson(`api/pet`, item) as Observable<void>;
  }

  public create(item: Pet): Observable<void>
  {
    return this.postAsJson(`api/pet`, item) as Observable<void>;
  }

  public delete(id: string): Observable<void>
  {
    return this.deleteById(`api/pet`, id) as Observable<void>;
  }
}
