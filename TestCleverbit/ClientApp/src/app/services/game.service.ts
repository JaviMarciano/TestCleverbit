import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IMatch from '../domain/match';

@Injectable({
  providedIn: 'root'
})

export class GameService {
  constructor(private http: HttpClient) { }

  public getallMatches(): Promise<IMatch[]> {
    return this.http.get<IMatch[]>("api/game/all-matches").toPromise();
  }
}
