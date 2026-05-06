using System.Text;

public static class Identifier
{
  public static string Clean(string identifier)
  {
    var sb = new StringBuilder();
    var i = 0;
    while (i < identifier.Length)
	{
      if (identifier[i] == '-' && i + 1 < identifier.Length)
	  {
        sb.Append(identifier[i + 1].ToString().ToUpper());
        i += 2;
      }
	  else
	  {
        sb.Append(identifier[i]);
        i++;
      }
    }     

    identifier = sb.ToString().Replace(" ", "_").Replace("\0", "CTRL");
    sb = new StringBuilder();
	
    foreach (var c in identifier)
	{
      if ((char.IsLetter(c) && c is < 'α' or > 'ω') || c == '_') sb.Append(c);
    }

    return sb.ToString();
  }
}