import IMatchItem from './match-item';

export default interface IUser {
  expiration: string,
  items: IMatchItem[];
}
