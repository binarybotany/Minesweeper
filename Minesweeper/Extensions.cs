using System.Security.Cryptography;

namespace Minesweeper;

public static class Extensions {
  public static void FisherYatesShuffle<T>(this IList<T> list) {
    using var rng = RandomNumberGenerator.Create();
    var length = list.Count;

    while(length > 1) {
      byte[] box = new byte[length];
      do rng.GetBytes(box);


      while (!(box[0] < length * (Byte.MaxValue / length)));
      int k = (box[0] % length);
      length--;

      T value = list[k];
      list[k] = list[length];
      list[length] = value;
    }
  }
}
