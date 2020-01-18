import IMatchItem from './match-item';

export default interface IUser {
  token: string
  expiration: string,
  items: IMatchItem[];
}
