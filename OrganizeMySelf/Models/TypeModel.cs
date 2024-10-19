using System;

public class TypeModel
{
    public int Id { get; set; }
    public string Type { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is TypeModel other)
        {
            return Id == other.Id && Type == other.Type;
        }
        return false;
    }

    public override int GetHashCode()
    {
        try
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + (Type?.GetHashCode() ?? 0);
            return hash;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetHashCode: {ex.Message}");
            throw;
        }
    }


}
