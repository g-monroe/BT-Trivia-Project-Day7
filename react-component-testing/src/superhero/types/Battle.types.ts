export interface IBattle {
    attackerID: number;
    defenderID: number;
    winnerID?: number;
    hasBattled: boolean;
}