import { Component, OnInit } from '@angular/core';
import IMatch from '../../domain/match';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-match-list',
  templateUrl: './match-list.component.html',
  styleUrls: ['./match-list.component.css']
})
export class MatchListComponent implements OnInit {

  matches: IMatch[] = [];

  constructor(private gameService: GameService) { }

  async ngOnInit() {
    this.matches = await this.gameService.getallMatches();
    console.log(this.matches);

  }

}
