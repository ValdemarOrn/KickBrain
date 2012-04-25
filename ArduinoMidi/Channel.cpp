#include "Channel.h"

Channel::Channel()
{
  data = 56;
}

void Channel::AddData(int d)
{
  this->data = data;
}


int Channel::GetData()
{
  return data;
}
