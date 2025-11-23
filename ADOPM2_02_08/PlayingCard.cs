using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPM2_02_08
{
	public enum PlayingCardColor
	{
		Clubs = 0, Diamonds, Hearts, Spades         // Poker suit order, Spades highest
	}
	public enum PlayingCardValue
	{
		Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
		Knight, Queen, King, Ace                // Poker Value order
	}
	public class PlayingCard
	{
		public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		string BlackOrRed
		{
			get
			{
				if (Color == PlayingCardColor.Clubs || Color == PlayingCardColor.Spades)
					return "Black";

				return "Red";
			}
		}
		public override string ToString() => $"{Value} of {Color}, a {BlackOrRed} card";
	}
}
